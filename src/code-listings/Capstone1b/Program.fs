open System
open Car

let getDestinationName() =
    Console.Write("Enter destination: ")
    Console.ReadLine()

let mutable petrol = 100
let mutable continueProcessing = true

[<EntryPoint>]
let main argv =
    while continueProcessing do
        try
            let destinationName = getDestinationName()
            if String.IsNullOrWhiteSpace(destinationName) = false then 
                printfn "Trying to drive to %s" destinationName
                petrol <- driveTo(petrol, destinationName)
                printfn "Made it to %s! You have %d petrol left" destinationName petrol
            else
                ignore(continueProcessing <- false)
        with ex -> printfn "ERROR: %s" ex.Message
    0