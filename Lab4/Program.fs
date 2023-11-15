open System

type StringTree =
    | Leaf of string
    | Node of string * StringTree list

let generateRandomWord length num_ex =
    let random = Random()
    let charList = if num_ex = 1 then List.init length (fun _ -> char (random.Next(65, 91))) else List.init length (fun _ -> char (random.Next(33, 91)))
    System.String(List.toArray charList)

let rec generateRandomStringTree depth num_ex=
    if depth <= 0 
    then Leaf(generateRandomWord 5 num_ex)
    else
        let random = Random()
        let nodeLength = random.Next(1, 3)
        Node(generateRandomWord 5 num_ex, List.init nodeLength  (fun _ -> generateRandomStringTree (depth-1) num_ex))

let rec printTree tree =
    match tree with
    | Leaf(value) ->
        printfn "Leaf: %s" value
    | Node(value, children) ->
        printfn "Node: %s" value
        List.iter printTree children
let do_exercise_1() =
    printf "\n----Выполнение задания 1----\n"
    let rec mapTree tree = 
        match tree with
        | Leaf(value) ->
            let new_value = value + value
            Leaf(new_value)
        | Node(value, children) ->
            let new_value = value + value
            Node(new_value, List.map mapTree children)

    printfn "\nВведенное дерево:\n"
    let tree = generateRandomStringTree 3 1
    printTree tree

    printfn "\nПолученное дерево:\n"
    let new_tree = mapTree tree
    printTree new_tree
    printf "\n\n"

let do_exercise_2() =
    printf "\n----Выполнение задания 2----\n"
    let rec foldTree tree (symbols:string) res =
        match tree with
        | Leaf(value) ->
            value.Contains(symbols)
        | Node(value, children) ->
            List.fold (fun res child -> res || value.Contains(symbols) || foldTree child symbols res) res children
        
    let tree = generateRandomStringTree 3 2
    printTree tree

    printfn "\nВведите символ для сравнения:"
    let symbols = Console.ReadLine()

    let new_bool = foldTree tree symbols false

    printfn "\nРезультат: %b" new_bool
    printf "\n\n"

printf "\n\nВыберите задание: 1 или 2\n"
let choice = System.Console.ReadLine()
match choice with
| "1" -> do_exercise_1()
| "2" -> do_exercise_2()
| _ -> failwith "Такого задания нет!"