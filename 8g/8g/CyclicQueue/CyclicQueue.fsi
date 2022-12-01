module CyclicQueue

type Value = int

/// <summary>Create or clear the cyclic queue</summary>
/// <param name="n">The maximum number of elements</param>
val create: n: int -> unit

/// <summary>Add an element to the end of a queue</summary>
/// <param name="e">an element</param>
/// <returns>True if the queue had space for the element</returns>
val enqueue: e: Value -> bool

/// <summary>Remove the element in the front position of the queue</summary>
/// <returns>The first element in q or None if the queue is empty</returns>
val dequeue: unit -> Value option

/// <summary>Check if the queue is empty</summary>
/// <returns>True if the queue is empty</returns>
val isEmpty: unit -> bool

/// <summary>Get the length of the queue</summary>
/// <returns>The number of elements in the queue</returns>
val length: unit -> int

/// <summary>The queue on string form</summary>
/// <returns>A string representing the queue's elements</returns>
val toString: unit -> string
