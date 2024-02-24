using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                ObservableCollection<int> oc = new ObservableCollection<int>();

                oc.CollectionChanged += followChange;

                // add
                oc.Add(1);
                oc.Add(2);
                oc.Add(3);
                oc.Add(4);
                oc.Add(5);

                // update
                oc[2] = 999;

                // remove
                oc.RemoveAt(3);

                // clear
                oc.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }



        // hàm để theo dõi sự thay đổi
        // theo dõi sự biến động
        public static void followChange(object sender, NotifyCollectionChangedEventArgs nccea)
        {
            try
            {
                switch (nccea.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        if (nccea.NewItems != null)
                        {
                            foreach (var item in nccea.NewItems)
                            {
                                Console.WriteLine($"Add: {item}");
                            }
                        }
                        break;

                    case NotifyCollectionChangedAction.Remove:
                        if (nccea.OldItems != null)
                        {
                            foreach (var item in nccea.OldItems)
                            {
                                Console.WriteLine($"Remove: {item}");
                            }
                        }
                        break;

                    case NotifyCollectionChangedAction.Replace:
                        if (nccea.NewItems != null)
                        {
                            Console.WriteLine($"Replace: {nccea.NewItems[0]}");
                        }
                        break;

                    case NotifyCollectionChangedAction.Reset:
                        Console.WriteLine("Clear");
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}