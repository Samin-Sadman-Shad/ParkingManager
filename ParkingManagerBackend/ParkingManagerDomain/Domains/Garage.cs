using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagerDomain.Domains
{
    public class Garage
    {
        public Guid Id { get; set; }

        public Guid GarageLocationId { get; set; }

        [ForeignKey(nameof(GarageLocationId))]
        public GarageLocation? GarageLocation { get; set; }
    }
}
