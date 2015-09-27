using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dalTractor;
using System.Data;

namespace appTractor.Model
{
    public class PartInventoryModel : IModelBase
    {
        private PartInventory partInventory;

        public int createPartInventory(PartInventory partInventory, int userId)
        {
            this.partInventory = partInventory;
            if (valid())
            {
                return PartInventoryDAL.create(partInventory.partId, partInventory.regDate, partInventory.DOInvoiceNo, partInventory.customerId,
                      partInventory.recd, partInventory.lSold, partInventory.gOnHand, partInventory.price, partInventory.oemRecd, partInventory.rSold, partInventory.imOnHand, partInventory.price2, partInventory.totalAvailabel, partInventory.totalDemand, partInventory.detail, userId);
            }
            else
            {
                return -1;
            }
        }

        private bool valid()
        {
            return (!String.IsNullOrEmpty(partInventory.DOInvoiceNo));
        }

        public List<PartInventory> getPartInventoryByPartId(int partId)
        {
            var partInventories = new List<PartInventory>();

            partInventories = PartInventoryDAL.getPartInventories(partId);

            int sumItemARecd = 0;
            int sumItemASold = 0;

            int sumItemBRecd = 0;
            int sumItemBSold = 0;

            foreach (var inventory in partInventories) {

                //G
                if (inventory.recd > 0)
                {
                    sumItemARecd = sumItemARecd + inventory.recd;
                }
                if (inventory.lSold > 0)
                {
                    sumItemASold = sumItemASold + inventory.lSold;
                }
                inventory.gOnHand = sumItemARecd - sumItemASold;

                //OEM
                if (inventory.oemRecd > 0) {
                    sumItemBRecd = sumItemBRecd + inventory.oemRecd;
                }
                if (inventory.rSold > 0)
                {
                    sumItemBSold = sumItemBSold + inventory.rSold;
                }
                inventory.imOnHand = sumItemBRecd - sumItemBSold;

                //total available
                inventory.totalAvailabel = inventory.gOnHand + inventory.imOnHand;

                //total demand
                inventory.totalDemand = sumItemASold + sumItemBSold;

            }

            return partInventories;
        }

        public void update(PartInventory cPartInventory, int userId)
        {
            partInventory = cPartInventory;
            if (valid())
            {
                PartInventoryDAL.update(partInventory.partInventoryId, partInventory.partId, partInventory.regDate, partInventory.DOInvoiceNo, partInventory.customerId,
                    partInventory.recd, partInventory.lSold, partInventory.gOnHand, partInventory.price, partInventory.oemRecd, partInventory.rSold, partInventory.imOnHand, partInventory.price2, partInventory.totalAvailabel, partInventory.totalDemand, partInventory.detail, userId);
            }
            else
            {
                throw new Exception("Invalid Part Inventory Data!");
            } 
        }

        public void delete(int partInventoryId, int userId)
        {
            PartInventoryDAL.deletePartInventoryById(partInventoryId, userId);
        }
    }
}
