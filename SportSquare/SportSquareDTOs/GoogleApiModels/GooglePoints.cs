using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSquareDTOs.GoogleApiModels
{
    public class GooglePoints : CollectionBase
    {

        public GooglePoints()
        {
        }

        public static GooglePoints CloneMe(GooglePoints prev)
        {
            GooglePoints p = new GooglePoints();
            for (int i = 0; i < prev.Count; i++)
            {
                p.Add(new GooglePoint(prev[i].ID, prev[i].Latitude, prev[i].Longitude, prev[i].IconImage, prev[i].InfoHTML, prev[i].ToolTip, prev[i].Draggable));
            }
            return p;
        }


        public GooglePoint this[int pIndex]
        {
            get
            {
                return (GooglePoint)this.List[pIndex];
            }
            set
            {
                this.List[pIndex] = value;
            }
        }

        public GooglePoint this[string pID]
        {
            get
            {
                for (int i = 0; i < Count; i++)
                {
                    if (this[i].ID == pID)
                    {
                        return (GooglePoint)this.List[i];
                    }
                }
                return null;
            }
            set
            {
                for (int i = 0; i < Count; i++)
                {
                    if (this[i].ID == pID)
                    {
                        this.List[i] = value;
                    }
                }
            }

        }

        public void Add(GooglePoint pPoint)
        {
            this.List.Add(pPoint);
        }
        public void Remove(int pIndex)
        {
            this.RemoveAt(pIndex);
        }
        public void Remove(string pID)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].ID == pID)
                {
                    this.List.RemoveAt(i);
                    return;
                }
            }
        }

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            GooglePoints p = obj as GooglePoints;
            if ((System.Object)p == null)
            {
                return false;
            }

            if (p.Count != Count)
                return false;


            for (int i = 0; i < p.Count; i++)
            {
                if (!this[i].Equals(p[i]))
                    return false;
            }
            // Return true if the fields match:
            return true;
        }
    }
}
