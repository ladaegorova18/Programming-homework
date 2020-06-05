module Downloader

open System.Net
open System.IO
open System.Text.RegularExpressions

let regex = new Regex ("<a href\s*=\s*\"?(https?://[^\"]+)\"?\s*>")

/// Download page and write url and page size
let fetchAsync url =
    async {
        try
            do printfn "Creating request for %s..." url
            let request = WebRequest.Create(url)
            use! response = request.AsyncGetResponse()
            do printfn "Getting response stream for %s..." url
            use stream = response.GetResponseStream()
            do printfn "Reading response for %s..." url
            use reader = new StreamReader(stream)
            let page = reader.ReadToEnd()
            do printfn "url: %s ------ length: %d" url page.Length
            return Some page
        with
            | _ -> 
            do printfn "error!"
            return None
    }
   
/// Find all links on page
let findLinks content = 
    regex.Matches(content) |> Seq.toList |> List.map (fun (x: Match) -> x.Groups.[1].Value) 

/// Download all links from page
let downloadLinks links =
    (List.map fetchAsync links) |> Async.Parallel |> Async.RunSynchronously |> Array.toList

/// Get all pages this page links to
let getAllPages content =
    match content with 
    | None -> ["None"]
    | Some page -> 
        let links = findLinks page
        List.map (fun (x: string option) -> x.Value) (downloadLinks links)
