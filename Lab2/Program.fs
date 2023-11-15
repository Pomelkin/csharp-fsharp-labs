//задание 1
open System

let do_exercise_1() =
    printf "\n----Выполнение задания 1----\n"
    let rec readNumbers acc =
        printfn "\nВведите число (или 'q' для завершения ввода):"
        let input = System.Console.ReadLine()

        match input with
        | "q" -> acc
        | _ ->
            try
                let number = int input
                let newAcc = number :: acc
                readNumbers newAcc
            with 
            | :? System.FormatException -> failwith "Некорректный ввод списка"
    printf "Введите исходный список\n"
    let numbers = readNumbers []

    

    printfn "\n\nВведенный список:"
    printfn "%A" (List.rev numbers)

    let sumOfDigits n =
        let rec sumOfDigitsHelper n acc =
            match n with
            | 0 -> acc
            | _ ->sumOfDigitsHelper (n / 10) (acc + abs(n % 10))
        sumOfDigitsHelper n 0
    let sumOfDigitsOfNumbers = List.map sumOfDigits numbers

    printfn "\n\nПолученный список:"
    printfn "%A\n\n" sumOfDigitsOfNumbers

//Задание 2
let do_exercise_2() =
    printf "\n----Выполнение задания 2----\n"
    let rec ReadNumbersForCompare acc =
        printfn "\nВведите число (или 'q' для завершения ввода):"
        let input = System.Console.ReadLine()

        match input with
        | "q" -> acc
        | _ ->
            try
                let number = float input
                let newAcc = number :: acc
                ReadNumbersForCompare newAcc
            with 
            | :? System.FormatException -> failwith "Некорректный ввод списка"

    printf "Введите исходный список\n"
    let numbersForCompare = ReadNumbersForCompare []

    printfn "\n\nВведенный список:"
    printfn "%A" (List.rev numbersForCompare)


    let sumElementsStartingWithDigit digit list =
        list
        |> List.filter (fun x -> abs(x).ToString().StartsWith(digit.ToString()))
        |> List.fold (fun acc elem -> acc + elem) 0.0

    try
    printfn "\n\nВведите число, с которым будет сравниваться первая цифра в числе:"
    let digitForCompare = float(System.Console.ReadLine())

    printfn "\n\nПолученная Сумма:"
    printfn "%.2f\n\n" (sumElementsStartingWithDigit digitForCompare numbersForCompare)
    with 
    | :? System.FormatException -> failwith "Некорректный ввод числа для сравнения"


printf "\n\nВыберите задание: 1 или 2\n"
let choice = System.Console.ReadLine()
match choice with
| "1" -> do_exercise_1()
| "2" -> do_exercise_2()
| _ -> failwith "Такого задания нет!"