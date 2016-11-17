using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstonEcole.DTO;
using AstonEcole.Services.Infrastructure;
using AstonEcole.DAL;
using System.Data.Entity;

namespace AstonEcole.Services
{
    public static class ExtensionCollection
    {


        public static void Remove<T>(this ICollection<T> collectionItem, int id) where T : IHasId
        {
            T item = collectionItem.Where(i => i.Id == id).FirstOrDefault();
            collectionItem.Remove(item);
        }


        public static void  updateCollection<T>(this ICollection<T> collectionToUpdate, ICollection<T> UpdatingCollection, DbContext context) where T : class, IHasId
        {
            // parcours des item  To Update
            foreach (T item in collectionToUpdate.ToList())
            {
                // si cet item n'existe pas dans l'UpdatingCollection => le supprimer
                if (!(UpdatingCollection.Any(c => c.Id == item.Id)))
                {
                    collectionToUpdate.Remove(item);
                }
            }

            
            // parcours des items de l'UpdatingCollection
            foreach (T item in UpdatingCollection.ToList())
            {
                // si l' item n'existe pas dans les items To update => le rajouter
                if (!(collectionToUpdate.Any(c => c.Id == item.Id)))
                {
                    // attacher l'item => retrouver l'item en base et pas en créer un nouveau
                    context.Entry(item).State = EntityState.Unchanged;                  
                    collectionToUpdate.Add(item);
                }
            }           

        }


    }
}
