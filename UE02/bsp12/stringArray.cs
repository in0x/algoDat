using System;
using System.Console;

namespace MyStringArray {
	
	class StringArray 
	{
		private string[] content;
		public string[] Content { get { return content; } }
		private int capacity;
		public int Capacity { get { return capacity; } }
		private int count;
		public int Count { get { return count; } }

		public StringArray()
		{
			content = new string[0]; 			
			capacity = 0;
			count = 0;
		}

		public StringArray(int _capacity)
		{
			if (_capacity < 0) 
				throw new Exception("Cannot initiate StringArray smaller than 0");
			content = new string[_capacity];
			capacity = _capacity;
			count = 0;
		} 

		public StringArray(string[] baseArray)
		{
			if (baseArray.Length < 4) 
			{
				capacity = 4;
				content = new string[4];
			} else {
				capacity = 4;
				while (capacity < baseArray.Length)
					capacity *= 2;
				content = new string[capacity];
				for (int index = 0; index < baseArray.Length; index++) 
				{
					content[index] = baseArray[index];
				}
			}
		}

		public void Add(string s) 
		{
			if(capacity == 0) 
				Resize(4);	
			if (count >= capacity) 
			{
				Resize(content.Length * 2);
			}
			content[count] = s;
			count++;
		}

		public void Resize(int size) 
		{
			string[] temp = new string[size];
			for (int index = 0; index < content.Length; index++) 
			{
				temp[index] = content[index];
			}
			content = temp;
			capacity = size;
		}

		public void Insert(string s, int position) 
		{
			if (position < 0) 
				throw new Exception("Cannot add at negative index");
			if (position >= count) 
				Add(s);
			else 
			{
				string[] temp = new string[content.Length];
				for (int index = 0; index <= position; index++) 
				{
					if (index == position) 
					{
						content[index] = s;
						continue;
					}
					temp[index] = content[index];
				}
				content = temp;
			}
		}

		public bool RemoveAt(int position) 
		{
			if (position > Capacity || position < 0) return false;
			string[] temp = new string[content.Length];
			for(int index = 0; index < position; index++)
			{
				temp[index] = content[index];
				temp[content.Length - index] = content[content.Length - index];
			}
			content = temp;
			return true;
		}
	}
}