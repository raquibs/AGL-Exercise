using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiClient.Models.Dto
{
    public class PersonDto
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public List<PetDto> pets { get; set; }
    }
}