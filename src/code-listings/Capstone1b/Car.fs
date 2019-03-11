module Car

open System

    type DestinationsType =
        | Home
        | Office
        | Stadium
        | GasStation
        | Unknown

    let getDestination destinationName =
        let destination = 
            match destinationName with
                | "home" -> DestinationsType.Home
                | "office" -> DestinationsType.Office
                | "stadium" -> DestinationsType.Stadium
                | "gas station" -> DestinationsType.GasStation
                | _ -> DestinationsType.Unknown
        destination

    let getPetrolUsagePerDestination destination =
        let petrolUsed =
            match destination with
                | Home -> 25
                | Office -> 50
                | Stadium -> 25
                | GasStation -> 10
                | _ -> 0
        petrolUsed
    
    let getPetrolReceivedPerDestination destination =
        let petrolUsed =
            match destination with
                | GasStation -> 50
                | _ -> 0
        petrolUsed

    // Drives to a given destination given a starting amount of petrol
    let driveTo (petrol, destinationName) = 
        let destination = getDestination destinationName
        let petrolLeft = 
            match destination with
                | Unknown -> invalidArg "destinationName" "Destination is unknown"
                | _ ->  let petrolRequired = getPetrolUsagePerDestination destination
                        let petrolReceived = getPetrolReceivedPerDestination destination
                        if petrol >= petrolRequired then petrol - petrolRequired + petrolReceived
                        else failwith ("Not enough petrol to drive to " + destination.ToString())
        petrolLeft