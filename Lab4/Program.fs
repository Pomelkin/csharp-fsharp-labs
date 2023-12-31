﻿open System

type StringTree =
    | Leaf of string
    | Node of string * StringTree list

let generateRandomWord length =
    let random = Random()
    let charList = List.init length (fun _ -> char (random.Next(33, 91)))
    System.String(List.toArray charList)

let rec generateRandomStringTree depth=
    if depth <= 0 
    then Leaf(generateRandomWord 5 )
    else
        let random = Random()
        let nodeLength = random.Next(1, 3)
        Node(generateRandomWord 5 , List.init nodeLength  (fun _ -> generateRandomStringTree (depth-1)))

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
    let random = Random()
    let treeDepth = random.Next(1, 6)
    let tree = generateRandomStringTree treeDepth
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
            value.Equals(symbols)
        | Node(value, children) ->
            List.fold (fun res child -> res || value.Equals(symbols) || foldTree child symbols res) res children
        
    let random = Random()
    let treeDepth = random.Next(1, 6)
    let tree = generateRandomStringTree treeDepth
    printTree tree

    printfn "\nВведите символы для сравнения:"
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