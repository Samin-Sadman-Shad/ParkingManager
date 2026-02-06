using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagerDomain.Domains
{
    internal class GarageRating:Rating
    {
        public Guid GarageId { get; set; }
        
        [ForeignKey(nameof(GarageId))]
        public Garage? Garage { get; set; }
    }
}
