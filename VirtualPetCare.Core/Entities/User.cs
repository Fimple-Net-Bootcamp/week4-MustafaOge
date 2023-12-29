namespace VirtualPetCareAPI.Entities
{
    public class User  : Entity
    {

        public string Name { get; set; }

        public string Email { get; set; }

        public List<Pet> Pets { get; set; }


    }
}


