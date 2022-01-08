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
        public string Number { get; private set; } = default!;
        public string? Name { get; private set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;
        public int OriginId { get; private set; }
        public Origin Origin { get; private set; } = default!;
        public int SexId { get; private set; }
        public Sex Sex { get; private set; } = default!;
        public int StatusId { get; private set; } = 1;
        public Status Status { get; private set; } = default!;
        public string? Color { get; private set; }
        public string? Raza { get; private set; }
        public DateTime BirthDate { get; private set; }
        public decimal BirthWeight { get; private set; } = 0;
        public DateTime AdmissionDate { get; private set; }
        public decimal IncomeWeight { get; private set; } = 0;
        public decimal ActualWeight { get; private set; } = 0;
        public int? SireId { get; private set; }
        public Animal? Sire { get; private set; }
        public int? DamId { get; private set; }
        public Animal? Dam { get; private set; }
        public string? Remarks { get; private set; }
        public string CreatedBy { get ; set ; }
        public DateTimeOffset CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }

        public void CalculateCategory(int ageDays)
        {
            this.CategoryId = ageDays switch
            {
                int value when value is > 0 and <= 240 => 1,
                int value when value is > 240 and <= 365 && this.Sex.Id == 1  => (int)Categories.NovillasDestete,
                int value when value is > 365 and <= 600 && this.Sex.Id == 1 => (int)Categories.NovillasDeLevante,
                int value when value is > 600 and <= 1080 && this.Sex.Id == 1 => (int)Categories.NovillaDeVientre,
                int value when value is > 240 and <= 365 && this.Sex.Id == 2 => (int)Categories.MautesDestete,
                int value when value is > 365 and <= 600 && this.Sex.Id == 2 => (int)Categories.MauteDeLevante,
                int value when value is > 600 and <= 1080 && this.Sex.Id == 2 => (int)Categories.MauteDeCeba,
                int value when value is > 1080 && this.Sex.Id == 1 => (int)Categories.Vacas,
                int value when value is > 1080 && this.Sex.Id == 2 => (int)Categories.Toros,
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

        public Animal(string number, string? name, int originId, int sexId, int statusId, string? color, string? raza, DateTime birthDate, decimal birthWeight, DateTime admissionDate, decimal incomeWeight, decimal actualWeight, int? sireId, int? damId, string? remarks)
        {
            Id = new Guid();
            Number = number;
            Name = name;
            this.CalculateCategory(CalculateAgeDays(this.BirthDate));
            OriginId = originId;
            SexId = sexId;
            StatusId = statusId;
            Color = color;
            Raza = raza;
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
