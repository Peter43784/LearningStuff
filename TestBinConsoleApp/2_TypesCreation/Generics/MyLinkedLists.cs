using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBinConsoleApp.TypesCreation.Generics {
	class Node {
		protected Node m_next;

		public Node(Node next) {
			m_next = next;
		}		
	}
	//LinkedList with different types
	class TypeNode<T> : Node{
		public T m_data;

		public TypeNode(T data ): this(data, null) {
			
		}
		public TypeNode( T data, Node next) : base(next) {
			m_data = data;
		}

		public override string ToString() {
			return m_data.ToString() + m_next?.ToString();
		}

	}
	//LinkedList with same types
	sealed class MyLinkedListNode<T> {
		public T m_data;
		public MyLinkedListNode<T> m_next;

		public MyLinkedListNode(T data) : this(data, null) {
			
		}

		public MyLinkedListNode(T data, MyLinkedListNode<T> next ) {
			m_data = data; m_next = next;
		}

		public override string ToString() {
			return m_data.ToString() + m_next?.ToString();
		}

	}
}
