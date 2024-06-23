// This is an implementation for doubly linked list
using System;
using System.Text;


namespace DataStructure {
    // Class for creating new node
    class Node {
        public int data;
        public Node next;
        public Node prev;

        public Node(int data) {
            this.data = data;
            next = prev = null;
        }
    }

    // class for creating doubly linked list
    class DoublyLinkedList {
        // intilize the head & tail to null
        private Node head = null;
        private Node tail = null;
        private int nodes_counter;

        // adding new nodes to the list;
        public void Add(int data) {
            Node newNode = new Node(data);
            if (head == null) {
                head = newNode;
                tail = newNode;
                nodes_counter++;
            } else {
                tail.next = newNode;
                newNode.prev = tail;
                tail = newNode;
                nodes_counter++;
            }
        }

        // Method to display all the nodes in the list
        public void DisplayLinkedList() {
            Node nodePtr = head;
            while (nodePtr != null) {
                Console.Write(nodePtr.data.ToString() + " -> ");
                nodePtr = nodePtr.next;
            }
        }

        // Method to print the nodes in reverse
        public void PrintReverseLinkedList() {
            Node nodePtr = tail;
            while (nodePtr != null) {
                Console.Write(nodePtr.data.ToString() + " -> ");
                nodePtr = nodePtr.prev;
            }
        }

        // Return number of nodes
       public int GetNumberOfNodes() {
            return nodes_counter;
        } 




        public void DeleteLast() {
            if (head == null) {
                return;
            }
            // if node is not empty
            // point at the tail and go to previous node
            Node nodePtr = tail;
            nodePtr = nodePtr.prev;
            tail = nodePtr;
            nodePtr.next = null;
            nodes_counter--;
        }
        public void DeleteFirst() {
            if (head == null) {
                return;
            }
            // point the head to the next node
            head = head.next;
            nodes_counter--;
        }

        // method to return element given it's index
        public int GetElement(int index) {
            if (index > nodes_counter || index < 0) return -1;
            Node nodePtr = head;
            int indexCounter = 0;
            while (indexCounter < index) { 
                nodePtr = nodePtr.next;
                indexCounter++;
            }
            return nodePtr.data;
        }

        public int GetElementIndex(int element) {
            if (head == null) return -1;
            Node nodePtr = head;
            int index = 0;
            while (nodePtr != null) {
                if (nodePtr.data == element)
                    return index;

                index++;
                nodePtr = nodePtr.next;
            }
            return -1;
        }

        // Add node at beginning
        public void AddNodeAtBegining(int data) {
            Node tempNode = new Node(data);
            tempNode.next = head.next;
            tempNode.prev = null;
            head = tempNode;
        }

        // Check if method is empty or not
        public bool IsEmpty() {
            // that returns the bool value for this expression
            return head == null;
        }

        // Empty linkes list
        // since it's has head and tail
        // gonna point both of them toward null
        public void EmptyLinkesList() {
            head = tail = null;
        }

        // remove node from specific index
        public void RemoveNodeAtIndex(int index) {
            if (index > nodes_counter || index < 0) return;

            Node nodePtr = head;
            int nodesIndex = 0;
            // iterate till find the node
            while (nodesIndex < index) {
                nodePtr = nodePtr.next;
                nodesIndex++;
            } 

            // make the previous node point to the next
            // of the node we want to delete
            // and make the next point to the prvious
            Node prevNode = nodePtr.prev;
            Node nextNode = nodePtr.next;
            prevNode.next = nextNode;
            nextNode.prev = prevNode;
            nodePtr = null;
        }

        // Turn list to array
        public int[] TurnListToArray() {
            Node nodePtr = head;
            int nodes = 0;

            // determin the size of array by # of nodes
            int[] arr = new int[nodes_counter];

            while (nodes < nodes_counter) {
                // add nodes value to the  array
                arr[nodes] = nodePtr.data;
                nodes++;
                nodePtr = nodePtr.next;
            }
            return arr;
        }

        // Turn list to string
        public StringBuilder TurnListToString() {
            Node nodePtr = head;
            StringBuilder nodesAsString = new StringBuilder();
            while (nodePtr != null) { 
                nodesAsString.Append(nodePtr.data.ToString());
                nodePtr = nodePtr.next;
            }
            return nodesAsString;
        }


    }


    class Program {
        public static void Main(string[] args) {
            DoublyLinkedList DoubleList = new DoublyLinkedList();
            DoubleList.Add(1);
            DoubleList.Add(2);
            DoubleList.Add(3);
            DoubleList.Add(4);
            DoubleList.Add(5);
            DoubleList.Add(6);
            //DoubleList.RemoveNodeAtIndex(4);
            //DoubleList.DisplayLinkedList();
            int[] arr = DoubleList.TurnListToArray();
            foreach (int i in arr) { 
                Console.WriteLine(i);
            }
            Console.WriteLine(DoubleList.TurnListToString());
        }
    }
}







