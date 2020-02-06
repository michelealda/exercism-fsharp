module SimpleCipher

open System

type SimpleCipher(key: string) =

    let calculate fn (a, b) =
        let offset = (fn (int a - 97) (int b - 97)) % 26
        if offset < 0 then offset + 26 else offset
        |> (+) 97
        |> char

    let encodeChar = calculate (+)
    let decodeChar = calculate (-)

    let transform fn (xs: string) =
        let k =
            if Seq.length key < 100
            then String.replicate (100 / Seq.length key) key
            else key

        k.[0..(Seq.length xs)]
        |> Seq.zip xs
        |> Seq.map fn
        |> Seq.toArray
        |> String

    member __.Key = key

    member __.Encode(plaintext: string) = plaintext |> transform encodeChar

    member __.Decode(ciphertext: string) = ciphertext |> transform decodeChar

    new() =
        let r = Random()
        let chars = [ 'a' .. 'z' ]
        let sz = List.length chars
        SimpleCipher(String(Array.init 100 (fun _ -> chars.[r.Next sz])))
