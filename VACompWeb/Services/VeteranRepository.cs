using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using VACompWeb.Models;
using VACompWeb.Areas.Identity.Data;
using VACompWeb.Data;
using Microsoft.AspNetCore.Identity;

namespace VACompWeb.Services
{
    public class VeteranRepository : IVeteranRepository
    {
        

        public VAUser GetVeteran(string id)
        {
            throw new NotImplementedException();
        }

        public VAUser UpdateVeteran(VAUser vetUpdate)
        {
            throw new NotImplementedException();
        }

        #region Constants for calc 
        public const float DisabilityRating10 = 152.64f;
        public const float DisabilityRating20 = 301.74f;
        public const float VetOnly30 = 467.39f;
        public const float VetOnly40 = 673.28f;
        public const float VetOnly50 = 958.44f;
        public const float VetOnly60 = 1214.03f;
        public const float VetOnly70 = 1529.95f;
        public const float VetOnly80 = 1778.43f;
        public const float VetOnly90 = 1998.52f;
        public const float VetOnly100 = 3332.06f;
        public const float VetSpouse30 = 522.46f;
        public const float VetSpouse40 = 747.41f;
        public const float VetSpouse50 = 1050.57f;
        public const float VetSpouse60 = 1325.22f;
        public const float VetSpouse70 = 1659.15f;
        public const float VetSpouse80 = 1926.69f;
        public const float VetSpouse90 = 2164.79f;
        public const float VetSpouse100 = 3517.84f;
        public const float VetSpouse1P30 = 566.94f;
        public const float VetSpouse1P40 = 806.71f;
        public const float VetSpouse1P50 = 1124.70f;
        public const float VetSpouse1P60 = 1414.18f;
        public const float VetSpouse1P70 = 1762.93f;
        public const float VetSpouse1P80 = 2045.30f;
        public const float VetSpouse1P90 = 2298.22f;
        public const float VetSpouse1P100 = 366.94f;
        public const float VetSpouse2P30 = 611.41f;
        public const float VetSpouse2P40 = 866.02f;
        public const float VetSpouse2P50 = 1198.83f;
        public const float VetSpouse2P60 = 1503.13f;
        public const float VetSpouse2P70 = 1866.71f;
        public const float VetSpouse2P80 = 2164.01f;
        public const float VetSpouse2P90 = 2431.65f;
        public const float VetSpouse2P100 = 3816.03f;
        public const float Vet1P30 = 511.87f;
        public const float Vet1P40 = 732.58f;
        public const float Vet1P50 = 1032.57f;
        public const float Vet1P60 = 1302.98f;
        public const float Vet1P70 = 1633.73f;
        public const float Vet1P80 = 1897.04f;
        public const float Vet1P90 = 2131.96f;
        public const float Vet1P100 = 3481.16f;
        public const float Vet2P30 = 556.35f;
        public const float Vet2P40 = 791.89f;
        public const float Vet2P50 = 1106.70f;
        public const float Vet2P60 = 1391.94f;
        public const float Vet2P70 = 1737.51f;
        public const float Vet2P80 = 2015.65f;
        public const float Vet2P90 = 2265.39f;
        public const float Vet2P100 = 3630.25f;
        public const float Vet1C30 = 504.45f;
        public const float Vet1C40 = 721.99f;
        public const float Vet1C50 = 1019.86f;
        public const float Vet1C60 = 1288.16f;
        public const float Vet1C70 = 1616.79f;
        public const float Vet1C80 = 1876.92f;
        public const float Vet1C90 = 2109.72f;
        public const float Vet1C100 = 3456.30f;
        public const float VetSpouse1C30 = 563.76f;
        public const float VetSpouse1C40 = 801.42f;
        public const float VetSpouse1C50 = 1118.35f;
        public const float VetSpouse1C60 = 1495.72f;
        public const float VetSpouse1C70 = 1754.46f;
        public const float VetSpouse1C80 = 2035.77f;
        public const float VetSpouse1C90 = 2287.63f;
        public const float VetSpouse1C100 = 3663.89f;
        public const float VetSpouse1C1P30 = 608.24f;
        public const float VetSpouse1C1P40 = 860.72f;
        public const float VetSpouse1C1P50 = 1192.48f;
        public const float VetSpouse1C1P60 = 1495.72f;
        public const float VetSpouse1C1P70 = 1858.24f;
        public const float VetSpouse1C1P80 = 2154.38f;
        public const float VetSpouse1C1P90 = 2421.06f;
        public const float VetSpouse1C1P100 = 3802.99f;
        public const float VetSpouse1C2P30 = 652.71f;
        public const float VetSpouse1C2P40 = 920.03f;
        public const float VetSpouse1C2P50 = 1266.61f;
        public const float VetSpouse1C2P60 = 1584.68f;
        public const float VetSpouse1C2P70 = 1962.02f;
        public const float VetSpouse1C2P80 = 2272.98f;
        public const float VetSpouse1C2P90 = 2554.50f;
        public const float VetSpouse1C2P100 = 3952.08f;
        public const float Vet1C1P30 = 548.93f;
        public const float Vet1C1P40 = 781.30f;
        public const float Vet1C1P50 = 1093.99f;
        public const float Vet1C1P60 = 1377.11f;
        public const float Vet1C1P70 = 1720.57f;
        public const float Vet1C1P80 = 1995.53f;
        public const float Vet1C1P90 = 2242.15f;
        public const float Vet1C1P100 = 3605.40f;
        public const float Vet1C2P30 = 593.41f;
        public const float Vet1C2P40 = 840.60f;
        public const float Vet1C2P50 = 1168.12f;
        public const float Vet1C2P60 = 1466.07f;
        public const float Vet1C2P70 = 1824.35f;
        public const float Vet1C2P80 = 2114.13f;
        public const float Vet1C2P90 = 2376.59f;
        public const float Vet1C2P100 = 3754.49f;
        public const float Plus1Under18C30 = 27.53f;
        public const float Plus1Under18C40 = 36.01f;
        public const float Plus1Under18C50 = 45.54f;
        public const float Plus1Under18C60 = 55.07f;
        public const float Plus1Under18C70 = 64.60f;
        public const float Plus1Under18C80 = 73.07f;
        public const float Plus1Under18C90 = 82.60f;
        public const float Plus1Under18C100 = 92.31f;
        public const float Plus1C18Plus30 = 88.96f;
        public const float Plus1C18Plus40 = 118.61f;
        public const float Plus1C18Plus50 = 148.26f;
        public const float Plus1C18Plus60 = 177.91f;
        public const float Plus1C18Plus70 = 208.62f;
        public const float Plus1C18Plus80 = 238.28f;
        public const float Plus1C18Plus90 = 267.93f;
        public const float Plus1C18Plus100 = 298.18f;
        public const float SpouseAid30 = 50.83f;
        public const float SpouseAid40 = 67.78f;
        public const float SpouseAid50 = 85.78f;
        public const float SpouseAid60 = 101.66f;
        public const float SpouseAid70 = 119.67f;
        public const float SpouseAid80 = 136.61f;
        public const float SpouseAid90 = 153.56f;
        public const float SpouseAid100 = 170.38f;

        #endregion

        public float CalculateMonthlyCompensation(int dependentStatusType, int childUnder18, int child18Plus, int rating, bool spouseAid)
        {
            float compensation = 0;
            if (rating == 10) return DisabilityRating10;
            if (rating == 20) return DisabilityRating20;
            switch ((dependentStatusType, rating))
            {
                // Veteran Only (no spouse or dependents)
                case (1, 30):
                    compensation = VetOnly30;
                    break;
                case (1, 40):
                    compensation = VetOnly40;
                    break;
                case (1, 50):
                    compensation = VetOnly50;
                    break;
                case (1, 60):
                    compensation = VetOnly60;
                    break;
                case (1, 70):
                    compensation = VetOnly70;
                    break;
                case (1, 80):
                    compensation = VetOnly80;
                    break;
                case (1, 90):
                    compensation = VetOnly90;
                    break;
                case (1, 100):
                    compensation = VetOnly100;
                    break;
                // Veteran w/Spouse (no parents or children) 
                case (2, 30):
                    compensation = VetSpouse30;
                    break;
                case (2, 40):
                    compensation = VetSpouse40;
                    break;
                case (2, 50):
                    compensation = VetSpouse50;
                    break;
                case (2, 60):
                    compensation = VetSpouse60;
                    break;
                case (2, 70):
                    compensation = VetSpouse70;
                    break;
                case (2, 80):
                    compensation = VetSpouse80;
                    break;
                case (2, 90):
                    compensation = VetSpouse90;
                    break;
                case (2, 100):
                    compensation = VetSpouse100;
                    break;
                // Veteran w/Spouse and 1 Parent Dependent (no children) 
                case (3, 30):
                    compensation = VetSpouse1P30;
                    break;
                case (3, 40):
                    compensation = VetSpouse1P40;
                    break;
                case (3, 50):
                    compensation = VetSpouse1P50;
                    break;
                case (3, 60):
                    compensation = VetSpouse1P60;
                    break;
                case (3, 70):
                    compensation = VetSpouse1P70;
                    break;
                case (3, 80):
                    compensation = VetSpouse1P80;
                    break;
                case (3, 90):
                    compensation = VetSpouse1P90;
                    break;
                case (3, 100):
                    compensation = VetSpouse1P100;
                    break;
                // Veteran w/Spouse and 2 Parent Dependents (no children)
                case (4, 30):
                    compensation = VetSpouse2P30;
                    break;
                case (4, 40):
                    compensation = VetSpouse2P40;
                    break;
                case (4, 50):
                    compensation = VetSpouse2P50;
                    break;
                case (4, 60):
                    compensation = VetSpouse2P60;
                    break;
                case (4, 70):
                    compensation = VetSpouse2P70;
                    break;
                case (4, 80):
                    compensation = VetSpouse2P80;
                    break;
                case (4, 90):
                    compensation = VetSpouse2P90;
                    break;
                case (4, 100):
                    compensation = VetSpouse2P100;
                    break;
                // Veteran w/1 Parent Dependent (no spouse or children)
                case (5, 30):
                    compensation = Vet1P30;
                    break;
                case (5, 40):
                    compensation = Vet1P40;
                    break;
                case (5, 50):
                    compensation = Vet1P50;
                    break;
                case (5, 60):
                    compensation = Vet1P60;
                    break;
                case (5, 70):
                    compensation = Vet1P70;
                    break;
                case (5, 80):
                    compensation = Vet1P80;
                    break;
                case (5, 90):
                    compensation = Vet1P90;
                    break;
                case (5, 100):
                    compensation = Vet1P100;
                    break;
                // Veteran w/2 Parent Dependents (no spouse or children)
                case (6, 30):
                    compensation = Vet2P30;
                    break;
                case (6, 40):
                    compensation = Vet2P40;
                    break;
                case (6, 50):
                    compensation = Vet2P50;
                    break;
                case (6, 60):
                    compensation = Vet2P60;
                    break;
                case (6, 70):
                    compensation = Vet2P70;
                    break;
                case (6, 80):
                    compensation = Vet2P80;
                    break;
                case (6, 90):
                    compensation = Vet2P90;
                    break;
                case (6, 100):
                    compensation = Vet2P100;
                    break;
                // Veteran w/Child (no spouse or parents)
                case (7, 30):
                    compensation = Vet1C30;
                    break;
                case (7, 40):
                    compensation = Vet1C40;
                    break;
                case (7, 50):
                    compensation = Vet1C50;
                    break;
                case (7, 60):
                    compensation = Vet1C60;
                    break;
                case (7, 70):
                    compensation = Vet1C70;
                    break;
                case (7, 80):
                    compensation = Vet1C80;
                    break;
                case (7, 90):
                    compensation = Vet1C90;
                    break;
                case (7, 100):
                    compensation = Vet1C100;
                    break;
                // Veteran w/Spouse and Child (no parents)
                case (8, 30):
                    compensation = VetSpouse1C30;
                    break;
                case (8, 40):
                    compensation = VetSpouse1C40;
                    break;
                case (8, 50):
                    compensation = VetSpouse1C50;
                    break;
                case (8, 60):
                    compensation = VetSpouse1C60;
                    break;
                case (8, 70):
                    compensation = VetSpouse1C70;
                    break;
                case (8, 80):
                    compensation = VetSpouse1C80;
                    break;
                case (8, 90):
                    compensation = VetSpouse1C90;
                    break;
                case (8, 100):
                    compensation = VetSpouse1C100;
                    break;
                // Veteran w/Spouse, Child and 1 Parent Dependent
                case (9, 30):
                    compensation = VetSpouse1C1P30;
                    break;
                case (9, 40):
                    compensation = VetSpouse1C1P40;
                    break;
                case (9, 50):
                    compensation = VetSpouse1C1P50;
                    break;
                case (9, 60):
                    compensation = VetSpouse1C1P60;
                    break;
                case (9, 70):
                    compensation = VetSpouse1C1P70;
                    break;
                case (9, 80):
                    compensation = VetSpouse1C1P80;
                    break;
                case (9, 90):
                    compensation = VetSpouse1C1P90;
                    break;
                case (9, 100):
                    compensation = VetSpouse1C1P100;
                    break;
                // Veteran w/Spouse, Child and 2 Parent Dependents
                case (10, 30):
                    compensation = VetSpouse1C2P30;
                    break;
                case (10, 40):
                    compensation = VetSpouse1C2P40;
                    break;
                case (10, 50):
                    compensation = VetSpouse1C2P50;
                    break;
                case (10, 60):
                    compensation = VetSpouse1C2P60;
                    break;
                case (10, 70):
                    compensation = VetSpouse1C2P70;
                    break;
                case (10, 80):
                    compensation = VetSpouse1C2P80;
                    break;
                case (10, 90):
                    compensation = VetSpouse1C2P90;
                    break;
                case (10, 100):
                    compensation = VetSpouse1C2P100;
                    break;
                // Veteran w/Child and 1 Parent Dependent (no spouse)
                case (11, 30):
                    compensation = Vet1C1P30;
                    break;
                case (11, 40):
                    compensation = Vet1C1P40;
                    break;
                case (11, 50):
                    compensation = Vet1C1P50;
                    break;
                case (11, 60):
                    compensation = Vet1C1P60;
                    break;
                case (11, 70):
                    compensation = Vet1C1P70;
                    break;
                case (11, 80):
                    compensation = Vet1C1P80;
                    break;
                case (11, 90):
                    compensation = Vet1C1P90;
                    break;
                case (11, 100):
                    compensation = Vet1C1P100;
                    break;
                // Veteran w/Child and 2 Parent Dependents
                case (12, 30):
                    compensation = Vet1C2P30;
                    break;
                case (12, 40):
                    compensation = Vet1C2P40;
                    break;
                case (12, 50):
                    compensation = Vet1C2P50;
                    break;
                case (12, 60):
                    compensation = Vet1C2P60;
                    break;
                case (12, 70):
                    compensation = Vet1C2P70;
                    break;
                case (12, 80):
                    compensation = Vet1C2P80;
                    break;
                case (12, 90):
                    compensation = Vet1C2P90;
                    break;
                case (12, 100):
                    compensation = Vet1C2P100;
                    break;
                default:
                    break;
            }
            if (spouseAid == true)
            {
                switch (rating)
                {
                    // More Compensation for Additional Children & Additional Aid
                    case 30:
                        compensation += (childUnder18 * Plus1Under18C30) + (child18Plus * Plus1C18Plus30) + SpouseAid30;
                        break;
                    case 40:
                        compensation += (childUnder18 * Plus1Under18C40) + (child18Plus * Plus1C18Plus40) + SpouseAid40;
                        break;
                    case 50:
                        compensation += (childUnder18 * Plus1Under18C50) + (child18Plus * Plus1C18Plus50) + SpouseAid50;
                        break;
                    case 60:
                        compensation += (childUnder18 * Plus1Under18C60) + (child18Plus * Plus1C18Plus60) + SpouseAid60;
                        break;
                    case 70:
                        compensation += (childUnder18 * Plus1Under18C70) + (child18Plus * Plus1C18Plus70) + SpouseAid70;
                        break;
                    case 80:
                        compensation += (childUnder18 * Plus1Under18C80) + (child18Plus * Plus1C18Plus80) + SpouseAid80;
                        break;
                    case 90:
                        compensation += (childUnder18 * Plus1Under18C90) + (child18Plus * Plus1C18Plus90) + SpouseAid90;
                        break;
                    case 100:
                        compensation += (childUnder18 * Plus1Under18C100) + (child18Plus * Plus1C18Plus100) + SpouseAid100;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (rating)
                {
                    // More Compensation for Additional Children & Additional Aid
                    case 30:
                        compensation += (childUnder18 * Plus1Under18C30) + (child18Plus * Plus1C18Plus30);
                        break;
                    case 40:
                        compensation += (childUnder18 * Plus1Under18C40) + (child18Plus * Plus1C18Plus40);
                        break;
                    case 50:
                        compensation += (childUnder18 * Plus1Under18C50) + (child18Plus * Plus1C18Plus50);
                        break;
                    case 60:
                        compensation += (childUnder18 * Plus1Under18C60) + (child18Plus * Plus1C18Plus60);
                        break;
                    case 70:
                        compensation += (childUnder18 * Plus1Under18C70) + (child18Plus * Plus1C18Plus70);
                        break;
                    case 80:
                        compensation += (childUnder18 * Plus1Under18C80) + (child18Plus * Plus1C18Plus80);
                        break;
                    case 90:
                        compensation += (childUnder18 * Plus1Under18C90) + (child18Plus * Plus1C18Plus90);
                        break;
                    case 100:
                        compensation += (childUnder18 * Plus1Under18C100) + (child18Plus * Plus1C18Plus100);
                        break;
                    default:
                        break;
                }
            }
            return compensation;
        }
    
    }
}
