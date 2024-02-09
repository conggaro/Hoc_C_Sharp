using System;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // tạo đối tượng "personEntity"
            // với các thuộc tính bên trong
            // được thiết lập sẵn giá trị
            PERSON_ENTITY personEntity = new PERSON_ENTITY
            {
                ID = 1,
                PERSON_NAME = "Nguyen Van A"
            };


            // tạo đối tượng "personDTO"
            PersonDTO personDTO = new PersonDTO();


            // gọi hàm ánh xạ
            Map_A_To_B<PERSON_ENTITY, PersonDTO>(ref personEntity, ref personDTO);


            // bây giờ personDTO
            // đã có giá trị
            // được lấy từ personEntity
            Console.WriteLine("Map Entity to DTO:");
            Console.WriteLine(personDTO.ToString());


            // có câu hỏi là
            // ánh xạ từ DTO sang Entity thì sao ?
            personDTO.Id = 2;
            personDTO.PersonName = "Nguyen Van B";


            // gọi hàm ánh xạ
            Map_A_To_B<PersonDTO, PERSON_ENTITY>(ref personDTO, ref personEntity);


            // câu trả lời là
            // có thể ánh xạ từ DTO sang Entity
            Console.WriteLine("\n\nMap DTO to Entity:");
            Console.WriteLine(personEntity.ToString());
        }


        // hàm ánh xạ
        // từ đối tượng A
        // sang đối tượng B
        public static void Map_A_To_B<E, D>(ref E source, ref D destination) where E : class where D : class
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            // lấy các thuộc tính của đối tượng nguồn (E)
            var sourceProperties = typeof(E).GetProperties();

            // lấy các thuộc tính của đối tượng đích (D)
            var destinationProperties = typeof(D).GetProperties();


            // source là "nguồn"
            // destination là "điểm đích"


            // dùng vòng lặp
            // để lặp qua các phần tử
            // của cái "điểm đến"
            foreach (var destinationProperty in destinationProperties)
            {
                // kiểm tra xem
                // có thuộc tính tương ứng
                // trong đối tượng nguồn không
                var sourceProperty = sourceProperties
                    .FirstOrDefault(p =>
                        p.Name.ToLower().Replace("_", "") == destinationProperty.Name.ToLower().Replace("_", "")
                        && p.PropertyType == destinationProperty.PropertyType);


                // nếu có thì nó khác null
                if (sourceProperty != null)
                {
                    // lấy giá trị từ đối tượng nguồn
                    var value = sourceProperty.GetValue(source);
                    
                    // gán vào đối tượng đích
                    destinationProperty.SetValue(destination, value);
                }

                // nếu không có thuộc tính tương ứng, bạn có thể xử lý hoặc bỏ qua tùy vào yêu cầu của bạn
            }
        }
    }


    public class PERSON_ENTITY
    {
        public int ID { get; set; }
        public string? PERSON_NAME { get; set; }


        // ghi đè phương thức ToString()
        public override string ToString()
        {
            return $"[{ID}, {PERSON_NAME}]";
        }
    }


    // DTO là viết tắt của "data transfer object"
    public class PersonDTO
    {
        public int Id { get; set; }
        public string? PersonName { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }


        // ghi đè phương thức ToString()
        public override string ToString()
        {
            return $"[{Id}, {PersonName}]";
        }
    }
}