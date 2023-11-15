//задание 1
open System
open System.IO
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
            | :? System.FormatException -> failwith "Некорректный ввод последовательности"

    printf "Введите исходную последовательность чисел:\n"
    let numbers = List.rev (readNumbers [])

    let seqOfNumbers = Seq.ofList numbers

    printfn "\n\nВведенная последовательность чисел:"
    printfn "%A" seqOfNumbers

    let sumOfDigits n =
        let rec sumOfDigitsHelper n acc =
            match n with
            | 0 -> acc
            | _ ->sumOfDigitsHelper (n / 10) (acc + abs(n % 10))
        sumOfDigitsHelper n 0
    let sumOfDigitsOfNumbers = Seq.map sumOfDigits seqOfNumbers

    printfn "\n\nCумма цифр натуральных чисел:"
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
            | :? System.FormatException -> failwith "Некорректный ввод последовательности"

    printf "Введите исходную последовательность чисел:\n"
    let numbersForCompare = List.rev(ReadNumbersForCompare [])

    let seqOfNumbersForCompare = Seq.ofList numbersForCompare

    printfn "\n\nВведенная последовательность чисел:"
    printfn "%A" seqOfNumbersForCompare


    let sumElementsStartingWithDigit digit seq =
        seq
        |> Seq.filter (fun x -> abs(x).ToString().StartsWith(digit.ToString()))
        |> Seq.fold (fun acc elem -> acc + elem) 0.0

    try
    printfn "\n\nВведите число, с которым будет сравниваться первая цифра в числе:"
    let digitForCompare = int(System.Console.ReadLine())

    printfn "\n\nПолученная Сумма:"
    printfn "%.2f\n\n" (sumElementsStartingWithDigit digitForCompare seqOfNumbersForCompare)
    with 

    | :? System.FormatException -> failwith "Некорректный ввод числа для сравнения"

//задание 3
let do_exercise_3() =
    printf "\n----Выполнение задания 3----\n"

    printf "\nВведите относительный путь до директории:\n"
    let path = System.Console.ReadLine()
    
    try
        let files = Directory.GetFiles(path)

        if files.Length = 0 then
            printfn "\nДиректория пуста"
        else 
            printf "\n\nВведите символ, с которого должно начинаться имя файла:\n"
            let symbol = System.Console.ReadLine()
            let filteredFiles = files |> Array.map (fun x -> Path.GetFileName(x)) |> Array.filter (fun x -> x.StartsWith(symbol))

            if filteredFiles.Length = 0 then
                printfn "\nВ директории нет файлов, начинающихся с заданного символа"
            else
                printfn "\nИмена файлов, начинающихся с заданного символа:"
                for file in filteredFiles do
                    printfn "%s" file
        printfn "\n"
    with
    | :? System.IO.DirectoryNotFoundException -> failwith "\nНекорректный ввод пути или дирректории не существует!\n\n"


printf "\n\nВыберите задание: 1, 2 или 3\n"
let choice = System.Console.ReadLine()
match choice with
| "1" -> do_exercise_1()
| "2" -> do_exercise_2()
| "3" -> do_exercise_3()
| _ -> failwith "Такого задания нет!"