using System.Collections;

namespace SportSquareDTOs.GoogleApiModels
{
    public class GooglePolygons : CollectionBase
    {

        public GooglePolygons()
        {
        }

        public static GooglePolygons CloneMe(GooglePolygons prev)
        {
            GooglePolygons p = new GooglePolygons();
            for (int i = 0; i < prev.Count; i++)
            {
                GooglePolygon GPL = new GooglePolygon();
                GPL.FillColor = prev[i].FillColor;
                GPL.FillOpacity = prev[i].FillOpacity;
                GPL.ID = prev[i].ID;
                GPL.Status = prev[i].Status;
                GPL.StrokeColor = prev[i].StrokeColor;
                GPL.StrokeOpacity = prev[i].StrokeOpacity;
                GPL.StrokeWeight = prev[i].StrokeWeight;
                GPL.Points = GooglePoints.CloneMe(prev[i].Points);
                p.Add(GPL);
            }
            return p;
        }

        public GooglePolygon this[int pIndex]
        {
            get
            {
                return (GooglePolygon)this.List[pIndex];
            }
            set
            {
                this.List[pIndex] = value;
            }
        }

        public GooglePolygon this[string pID]
        {
            get
            {
                for (int i = 0; i < Count; i++)
                {
                    if (this[i].ID == pID)
                    {
                        return (GooglePolygon)this.List[i];
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

        public void Add(GooglePolygon pPolygon)
        {
            this.List.Add(pPolygon);
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
