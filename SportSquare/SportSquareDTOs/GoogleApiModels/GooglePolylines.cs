using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSquareDTOs.GoogleApiModels
{
    public class GooglePolylines : CollectionBase
    {

        public GooglePolylines()
        {
        }

        public static GooglePolylines CloneMe(GooglePolylines prev)
        {
            GooglePolylines p = new GooglePolylines();
            for (int i = 0; i < prev.Count; i++)
            {
                GooglePolyline GPL = new GooglePolyline();
                GPL.ColorCode = prev[i].ColorCode;
                GPL.Geodesic = prev[i].Geodesic;
                GPL.ID = prev[i].ID;
                GPL.Points = GooglePoints.CloneMe(prev[i].Points);
                GPL.Width = prev[i].Width;
                p.Add(GPL);
            }
            return p;
        }

        public GooglePolyline this[int pIndex]
        {
            get
            {
                return (GooglePolyline)this.List[pIndex];
            }
            set
            {
                this.List[pIndex] = value;
            }
        }

        public GooglePolyline this[string pID]
        {
            get
            {
                for (int i = 0; i < Count; i++)
                {
                    if (this[i].ID == pID)
                    {
                        return (GooglePolyline)this.List[i];
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

        public void Add(GooglePolyline pPolyline)
        {
            this.List.Add(pPolyline);
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

    }
}
