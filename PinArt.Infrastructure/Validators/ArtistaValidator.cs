using FluentValidation;
using PinArt.Core.DTOs;
using PinArt.Core.DTOs.Artista;
using System;
using System.Collections.Generic;
using System.Text;

namespace PinArt.Infrastructure.Validators
{
    public class ArtistaValidator : AbstractValidator<SaveArtistaDto>
    {
        public ArtistaValidator()
        {
            RuleFor(artista => artista.Nombre)
                .NotEmpty().WithMessage("El nombre es requerido")
                .Length(1, 25).WithMessage("Maximo de caracteres 25");

            RuleFor(artista => artista.Apellido1)
                .NotEmpty().WithMessage("El primer apellido es requerido");

            RuleFor(artista => artista.PaisId)
                .NotEmpty().WithMessage("El pais es requerido");
        }
    }
}

