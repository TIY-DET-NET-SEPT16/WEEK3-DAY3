using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ReadWriteXML
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> myBooks = new List<Book>();

            XmlDocument doc = new XmlDocument();
            doc.Load("booksXMLFile.xml");

            XmlNode catNode = doc.DocumentElement.SelectSingleNode("/catalog");

            foreach(XmlNode child in catNode.ChildNodes)
            {
                Book book = new Book();
                foreach(XmlNode grandChild in child.ChildNodes)
                {
                    switch (grandChild.Name)
                    {
                        case "author":
                            {
                                book.Author = grandChild.InnerText;
                                break;
                            }
                        case "title":
                            {
                                book.Title = grandChild.InnerText;
                                break;
                            }
                        case "genre":
                            {
                                book.Genre = grandChild.InnerText;
                                break;
                            }
                        case "price":
                            {
                                book.Price = Convert.ToDouble(grandChild.InnerText);
                                break;
                            }
                        case "publish_date":
                            {
                                book.PublishDate = Convert.ToDateTime(grandChild.InnerText);
                                break;
                            }
                        case "description":
                            {
                                book.Description = grandChild.InnerText;
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
                myBooks.Add(book);
            }
        }
    }
}
