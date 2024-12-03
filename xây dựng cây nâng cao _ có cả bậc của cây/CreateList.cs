namespace MyApp
{
    public static class CreateList
    {
        public static List<Node> CreateListDepartment()
        {
            List<Node> departments = new List<Node>()
            {
                new Node { Id = 1, Name = "CEO Office", ParentId = null },
                new Node { Id = 2, Name = "Finance Department", ParentId = 1 },
                new Node { Id = 3, Name = "Human Resources", ParentId = 1 },
                new Node { Id = 4, Name = "IT Department", ParentId = 1 },
                new Node { Id = 5, Name = "Sales Department", ParentId = 1 },
                new Node { Id = 6, Name = "Marketing Department", ParentId = 1 },
                new Node { Id = 7, Name = "Legal Department", ParentId = 1 },
                new Node { Id = 8, Name = "R&D Department", ParentId = 1 },
                new Node { Id = 9, Name = "Customer Support", ParentId = 5 },
                new Node { Id = 10, Name = "Accounting", ParentId = 2 },
                new Node { Id = 11, Name = "Payroll", ParentId = 2 },
                new Node { Id = 12, Name = "Recruitment", ParentId = 3 },
                new Node { Id = 13, Name = "Training", ParentId = 3 },
                new Node { Id = 14, Name = "Network Team", ParentId = 4 },
                new Node { Id = 15, Name = "Software Team", ParentId = 4 },
                new Node { Id = 16, Name = "Hardware Team", ParentId = 4 },
                new Node { Id = 17, Name = "Domestic Sales", ParentId = 5 },
                new Node { Id = 18, Name = "International Sales", ParentId = 5 },
                new Node { Id = 19, Name = "Digital Marketing", ParentId = 6 },
                new Node { Id = 20, Name = "Content Marketing", ParentId = 6 },
                new Node { Id = 21, Name = "Creative Team", ParentId = 6 },
                new Node { Id = 22, Name = "Legal Consulting", ParentId = 7 },
                new Node { Id = 23, Name = "Compliance", ParentId = 7 },
                new Node { Id = 24, Name = "Product Research", ParentId = 8 },
                new Node { Id = 25, Name = "Innovation Team", ParentId = 8 },
                new Node { Id = 26, Name = "Customer Retention", ParentId = 9 },
                new Node { Id = 27, Name = "Technical Support", ParentId = 9 },
                new Node { Id = 28, Name = "Accounting Receivable", ParentId = 10 },
                new Node { Id = 29, Name = "Accounting Payable", ParentId = 10 },
                new Node { Id = 30, Name = "Talent Acquisition", ParentId = 12 },
                new Node { Id = 31, Name = "Employee Development", ParentId = 13 },
                new Node { Id = 32, Name = "Infrastructure Team", ParentId = 14 },
                new Node { Id = 33, Name = "Cybersecurity", ParentId = 14 },
                new Node { Id = 34, Name = "Software Development", ParentId = 15 },
                new Node { Id = 35, Name = "Mobile App Team", ParentId = 15 },
                new Node { Id = 36, Name = "PC Repair Team", ParentId = 16 },
                new Node { Id = 37, Name = "Server Management", ParentId = 16 },
                new Node { Id = 38, Name = "B2B Sales", ParentId = 17 },
                new Node { Id = 39, Name = "B2C Sales", ParentId = 17 },
                new Node { Id = 40, Name = "Export Team", ParentId = 18 },
                new Node { Id = 41, Name = "Import Team", ParentId = 18 },
                new Node { Id = 42, Name = "SEO Team", ParentId = 19 },
                new Node { Id = 43, Name = "Advertising Team", ParentId = 19 },
                new Node { Id = 44, Name = "Content Writers", ParentId = 20 },
                new Node { Id = 45, Name = "Graphic Designers", ParentId = 21 },
                new Node { Id = 46, Name = "Contracts Team", ParentId = 22 },
                new Node { Id = 47, Name = "Regulatory Affairs", ParentId = 23 },
                new Node { Id = 48, Name = "Prototype Development", ParentId = 24 },
                new Node { Id = 49, Name = "Innovation Research", ParentId = 25 },
                new Node { Id = 50, Name = "Field Support", ParentId = 27 }
            };

            return departments;
        }
    }
}