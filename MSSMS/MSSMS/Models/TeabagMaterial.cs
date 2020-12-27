using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSMS.Models
{
    public class TeabagMaterial
    {
        public string materialId { get; private set; }
        public string materialName { get; private set; }
        public string teabagType { get; private set; }
        public string materialSerialNo { get; private set; }
        public string materialDescription { get; private set; }
        public string materialAvailability { get; private set; }

        public TeabagMaterial(string materialId, string materialSerialNo)
        {
            this.materialId = materialId;
            this.materialSerialNo = materialSerialNo;
        }

        public TeabagMaterial(string materialId, string materialName, string teabagType, string materialSerialNo, string materialDescription, string materialAvailability)
        {
            this.materialId = materialId;
            this.materialName = materialName;
            this.teabagType = teabagType;
            this.materialSerialNo = materialSerialNo;
            this.materialDescription = materialDescription;
            this.materialAvailability = materialAvailability;
        }

        public TeabagMaterial(string materialName, string teabagType, string materialSerialNo, string materialDescription, string materialAvailability)
        {
            this.materialName = materialName;
            this.teabagType = teabagType;
            this.materialSerialNo = materialSerialNo;
            this.materialDescription = materialDescription;
            this.materialAvailability = materialAvailability;
        }
    }
}
