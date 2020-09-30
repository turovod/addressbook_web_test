using System;

namespace AddressbookWebTest
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {

        public string Name { get; set; }

        public string Header { get; set; }

        public string Footer { get; set; }
        
        public string Id { get; set; }

        public int RowModify { get; set; }

        // The default constructor is needed for the Xnl Serializer (convertor)
        public GroupData()
        {
        }

        public GroupData(string name)
        {
            this.Name = name;
        }

        // Реализация интерфейса IEquatable для организации сравнения объектов. По умолчанию объекты равны, если ссылки на 
        // один и тот же объект

        public bool Equals(GroupData other)
        {
            return Name.Equals(other.Name);

            //// Проверки по правилам хорошего кода
            //if (this == other) // Если объекты равны, то и элементы равны
            //{
            //    return true;
            //}

            //// Проверки по правилам хорошего кода
            //if (this == null) // Если сравниваемый объект не существует, то точно не равны
            //{
            //    return false;
            //}

            //if (this.Name == other.Name) // Сравниваем только по имени (правило сравнения)
            //{
            //    return true;
            //}

            //return false;
        }

        // Реализация интерфейса IComparable для организации упорядочивания объектов.
        // Возвращает 1 если текущий объект больше other, -1 если текущий объект меньше other и 0 если равны.
        public int CompareTo(GroupData other)
        {
             return Name.CompareTo(other.Name);
        }
    }
}
