using Hatogan.Domain.Enums;
using Hatogan.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatogan.Domain.Entities
{
    public class Animal : BaseEntity<Guid>, IAuditEntity, IAggregateRoot
    {
        public string Number { get; init; } = default!;
        public string? Name { get; init; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;
        public short OriginId { get; init; }
        public Origin Origin { get; init; } = default!;
        public short SexId { get; init; }
        public Sex Sex { get; init; } = default!;
        public short StatusId { get; init; } = 1;
        public Status Status { get; init; } = default!;
        public string? Color { get; init; }
        public string? Breed { get; init; }
        public DateTime BirthDate { get; init; }
        public decimal BirthWeight { get; init; } = 0;
        public DateTime AdmissionDate { get; init; }
        public decimal IncomeWeight { get; init; } = 0;
        public decimal ActualWeight { get; init; } = 0;
        public Guid? SireId { get; init; }
        public Animal? Sire { get; init; }
        public Guid? DamId { get; init; }
        public Animal? Dam { get; init; }
        public string? Remarks { get; init; }

        public List<Animal> DamPups { get; set; } = new List<Animal>();
        public List<Animal> SirePups { get; set; } = new List<Animal>();

        public string CreatedBy { get; set; } = default!;
        public DateTimeOffset CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }

        public void CalculateCategory(int ageDays)
        {
            this.CategoryId = ageDays switch
            {
                int value when value is > 0 and <= 240 => 1,
                int value when value is > 240 and <= 365 && this.SexId == 1  => (int)Categories.NovillasDestete,
                int value when value is > 365 and <= 600 && this.SexId == 1 => (int)Categories.NovillasDeLevante,
                int value when value is > 600 and <= 1080 && this.SexId == 1 => (int)Categories.NovillaDeVientre,
                int value when value is > 240 and <= 365 && this.SexId == 2 => (int)Categories.MautesDestete,
                int value when value is > 365 and <= 600 && this.SexId == 2 => (int)Categories.MauteDeLevante,
                int value when value is > 600 and <= 1080 && this.SexId == 2 => (int)Categories.MauteDeCeba,
                int value when value is > 1080 && this.SexId == 1 => (int)Categories.Vacas,
                int value when value is > 1080 && this.SexId == 2 => (int)Categories.Toros,
                _ => (int)Categories.Vacas,
            };
        }

        public int CalculateAgeDays(DateTime birthDate)
        {
                int year = birthDate.Year;

                int leapYear = 0;

                for (int i = year; i < DateTime.Now.Year; i++)
                {
                    if (DateTime.IsLeapYear(i))
                    {
                        ++leapYear;
                    }
                }

                TimeSpan timeSpan = DateTime.Now.Subtract(birthDate.Date);
                var ageDays = timeSpan.Days - leapYear;
                return ageDays;
        }

        public void AddDamPups(Animal damPup)
        {
            var exist = this.DamPups.Any(a => a.Number == damPup.Number);
            if(exist)
            {
                throw new Exception("Ya existe una cria con ese Numero para este animal");
            }

            if(damPup.Number == this.Number)
            {
                throw new Exception("Error no puede asignar a la cria el mismo numero de la mama");
            }

            this.DamPups.Add(damPup);
        }

        public void AddSirePups(Animal sirePup)
        {
            var exist = this.SirePups.Any(a => a.Number == sirePup.Number);
            if (exist)
            {
                throw new Exception("Ya existe una cria con ese Numero para este animal");
            }

            if (sirePup.Number == this.Number)
            {
                throw new Exception("Error no puede asignar a la cria el mismo numero del papá");
            }
            this.SirePups.Add(sirePup);
        }

        public Animal(string number, string? name, short originId, short sexId, short statusId, string? color, string? breed, DateTime birthDate, decimal birthWeight, DateTime admissionDate, decimal incomeWeight, decimal actualWeight, Guid? sireId, Guid? damId, string? remarks)
        {
            Id = new Guid();
            Number = number;
            Name = name;
            this.CalculateCategory(CalculateAgeDays(this.BirthDate));
            OriginId = originId;
            SexId = sexId;
            StatusId = statusId;
            Color = color;
            Breed = breed;
            BirthDate = birthDate;
            BirthWeight = birthWeight;
            AdmissionDate = admissionDate;
            IncomeWeight = incomeWeight;
            ActualWeight = actualWeight;
            SireId = sireId;
            DamId = damId;
            Remarks = remarks;
        }
    }
}
