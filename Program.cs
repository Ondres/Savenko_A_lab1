using System;
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace lab1csh
{
    class Sent
    {
        private string s;

        public string S
        {
            get { return s; }
            set { s = value; }
        }

        public Sent(string s)
        {
            this.s = s;
        }
        public void AddWord(string s)
        {
            this.s += " ";
            this.s += s;
        }
        public void DeleteWord(string s)
        {
            if (this.s.Contains(s))
            {
                string[] box = this.s.Split();
                for (int i = 0; i < box.Length; i++)
                    if (box[i] == s)
                    {
                        box[i] = "";
                    }
                this.s = "";
                for (int i = 0; i < box.Length; i++)
                {
                    if (box[i] != "")
                    {
                        this.s += box[i];
                        this.s += " ";
                    }
                }
            }
        }

        public void InsertWord(string s, int index)
        {
            string[] box = this.s.Split();
            box[index-1] += " " + s;
            this.s = "";
            for (int i = 0; i < box.Length; i++)
            {
                if (box[i] != "")
                {
                    this.s += box[i];
                    this.s += " ";
                }
            }
        }
        public void NumOfLet()
        {
            Console.WriteLine("There are " + s.Length + " letters");
        }
        public void NumOfW()
        {
            int c = 0;
            for (int i = 0; i < s.Length; i++)
                if (s[i] == ' ')
                    c++;
            Console.WriteLine("There are " + c + " words");
        }

        public void longestW()
        {
            string[] box = s.Split();
            string lw = box[0]; 
            for (int i = 1; i < box.Length; i++)
            {
                if (box[i].Length >= lw.Length)
                    lw = box[i];
            }
            Console.WriteLine("longest word is " + lw);
        }

        public void ShortestW()
        {
            string[] box = s.Split();
            string lw = box[1];
            for (int i = 0; i < box.Length; i++)
            {
                if (i == box.Length - 1) 
                Console.WriteLine("shortest word is " + lw + " ");
                if (lw.Length > box[i].Length)
                    lw = box[i];
            }
        }

        public void ExistW(string s)
        {
           
            if (this.s.Contains(s))
            {
                Console.WriteLine("Yes");
            }
            else
                Console.WriteLine("No");
        }
        public void ExistWn(int n)
        {
            string[] box = s.Split();
            if (n > 0 && n <= box.Length)
            {
                Console.WriteLine("Yes");
            }
            else
                Console.WriteLine("No");
        }
        public void Compare(string s)
        {
            int c = 0;
            if (this.s.Length == s.Length)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (this.s[i] != s[i])
                        c++;
                }
                if (c == 0)
                    Console.WriteLine("Yes");
                else
                    Console.WriteLine("No");
            }
            else
                Console.WriteLine("No");
        }
        public void InF(Sent sent)
        {
            File.WriteAllText("sent.json", JsonConvert.SerializeObject(sent));
        }
        public Sent FromF()
        {
            var sent = File.Exists("sent.json") ? JsonConvert.DeserializeObject<Sent>(File.ReadAllText("sent.json")) : new Sent("It is a long established fact that a reader will be")
            {
            };
            return sent;
        }



    }
    class Program
    {
        static void Main(string[] args)
        {
            Sent s = new Sent("It is a long established fact that a reader will be");

            s.InF(s);

            Sent s2 = s.FromF();
            Console.WriteLine("s2 text = " + s2.S);


            Console.WriteLine("s1 text = " + s.S);

            string sp;
            Console.WriteLine("Enter Word to Add");
            sp = Console.ReadLine();
            s.AddWord(sp);
            Console.WriteLine("s1 text = " + s.S);

            Console.WriteLine("Enter Word to Delete");
            sp = Console.ReadLine();
            s.DeleteWord(sp);
            Console.WriteLine("s1 text = " + s.S);

            Console.WriteLine("Enter Word to Insert");
            sp = Console.ReadLine();
            Console.WriteLine("And its position");
            int k = Convert.ToInt32(Console.ReadLine());
            s.InsertWord(sp, k);
            Console.WriteLine("s1 text = " + s.S);

            Console.WriteLine("Enter Word to Find if it exists");
            sp = Console.ReadLine();
            s.ExistW(sp);
            Console.WriteLine("s1 text = " + s.S);

            Console.WriteLine("Enter number of word to Find if it exists");
            k = Convert.ToInt32(Console.ReadLine());
            s.ExistWn(k);
            Console.WriteLine("s1 text = " + s.S);

            s.ShortestW();

            s.longestW();
            s.NumOfLet();
            s.NumOfW();

            Console.WriteLine("s1 text = " + s.S);
            Console.WriteLine("Enter string to Compare with");
            sp = Console.ReadLine();
            s.Compare(sp);


        }
    }
}
