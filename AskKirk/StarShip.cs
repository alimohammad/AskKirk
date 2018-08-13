using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AskKirk
{
    partial class Program
    {
        [DataContract(Name="starship")]
        public class StarShip
        {
            [DataMember(Name="name")]
            public string Name { get; set; }
            [DataMember(Name="model")]
            public string Model { get; set; }
            [DataMember(Name="manufacturer")]
            public string Manufacturer { get; set; }
            public string CostInCredits { get; set; }
            public string Length { get; set; }
            [DataMember(Name="max_atmosphering_speed")]
            public string MaxAtmospheringSpeed { get; set; }
            public string Crew { get; set; }
            public string Passengers { get; set; }
            [DataMember(Name="cargo_capacity")]
            public string CargoCapacity { get; set; }
            public string Consumables { get; set; }
            [DataMember(Name="hyperdrive_rating")]
            public string HyperdriveRating { get; set; }
            public string Mglt { get; set; }
            [DataMember(Name="starship_class")]
            public string StarshipClass { get; set; }
            public List<object> Pilots { get; set; }
            public List<string> Films { get; set; }
            public DateTime Created { get; set; }
            public DateTime Edited { get; set; }
            public string Url { get; set; }
        }
    }
}