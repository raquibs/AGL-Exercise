using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiClient.Models.Dto
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public List<PetDto> pets { get; set; }
    }
}