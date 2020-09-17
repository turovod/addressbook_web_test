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

        // Реализация интерфейса IEquatable для организации сравнения оъектов. По умолчанию объекты равны, если ссылки на 
        // один и тот же объект

        public bool Equals(GroupData other)
        {
            // Проверки по правилам хорошего кода
            if (this == other) // Если объекты равны, то и элементы равны
            {
                return true;
            }

            // Проверки по правилам хорошего кода
            if (this == null) // Если сравниваемый объект не существует, то точно не равны
            {
                return false;
            }

            if (this.Name == other.Name) // Сравниваем только по имени (правило сравнения)
            {
                return true;
            }

            return false;
        }

        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            return Name.CompareTo(other.Name);
        }

        public GroupData(string name)
        {
            this.Name = name;
        }
    }
}
