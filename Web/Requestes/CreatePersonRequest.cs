﻿using estulo_mediatr_crud_pessoa.Models.Enumerators;

namespace Web.Requestes
{
    public class CreatePersonRequest
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Sexo Sexo { get; set; }
    }
}
