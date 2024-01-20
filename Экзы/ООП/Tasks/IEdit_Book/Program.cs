using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DocumentApp
{
    public interface IEdit
    {
        void Delete();
    }

    public abstract class Redactor
    {
        public StringBuilder Text { get; set; }

        public abstract void Delete();

        public override string ToString()
        {
            return $"Text: {Text}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Redactor other = (Redactor)obj;
            return Text.ToString() == other.Text.ToString();
        }

        public override int GetHashCode()
        {
            return Text.GetHashCode();
        }
    }

    public class Document : Redactor, IEdit
    {
        public override void Delete()
        {
            // Удаление всех слов, кроме первого
            string[] words = Text.ToString().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (words.Length > 1)
            {
                Text.Clear();
                Text.Append(words[0]);
            }
        }

        public override string ToString()
        {
            return $"Document: {base.ToString()}";
        }

        public void Print(string fileName)
        {
            using (StreamWriter file = new StreamWriter(fileName))
            {
                file.Write(Text.ToString());
            }
        }
    }

    public class Book : Document
    {
        public override void Delete()
        {
            // Удаление лишних пробелов
            string trimmedText = Text.ToString().Trim();
            Text.Clear();
            Text.Append(trimmedText);
        }

        public override string ToString()
        {
            return $"Book: {base.ToString()}";
        }

        public new void Print(string fileName)
        {
            string[] sentences = Text.ToString().Split('.', StringSplitOptions.RemoveEmptyEntries);
            using (StreamWriter file = new StreamWriter(fileName))
            {
                foreach (string sentence in sentences)
                {
                    file.WriteLine(sentence.Trim());
                }
            }
        }
    }

    public static class BookExtensions
    {
        public static void ToBeContinued(this Book book)
        {
            Console.WriteLine("To be continued...");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Redactor> archive = new List<Redactor>();
                archive.Add(new Document() { Text = new StringBuilder("   This is a test document.   ") });
                archive.Add(new Document() { Text = new StringBuilder("   Hello world. How are you?   ") });
                archive.Add(new Document() { Text = new StringBuilder("   Delete all but first.   ") });
                archive.Add(new Book() { Text = new StringBuilder("   This is a test book.   ") });
                archive.Add(new Book() { Text = new StringBuilder("   Chapter 1. Introduction. Chapter 2. Conclusion.   ") });

                foreach (var item in archive)
                {
                    item.Delete();
                    string fileName = $"output_{DateTime.Now:ddMMyyyy(HHmmss)}.txt";
                    if (item is Document)
                    {
                        Document document = (Document)item;
                        document.Print(fileName);
                    }
                    else if (item is Book)
                    {
                        Book boook = (Book)item;
                        boook.Print(fileName);
                    }
                    Console.WriteLine(item.ToString());
                }

                Book book = new Book() { Text = new StringBuilder("   Chapter 1. Introduction.   ") };
                book.Delete();
                string bookFileName = $"output_{DateTime.Now:ddMMyyyy(HHmmss)}.txt";
                book.Print(bookFileName);
                book.ToBeContinued();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}