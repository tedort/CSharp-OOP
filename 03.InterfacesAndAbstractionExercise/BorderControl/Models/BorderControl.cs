﻿namespace BorderControl.Models
{
    public class BorderControl
    {
        private List<BaseEntity> entities; // Robots + Citizens

        public List<BaseEntity> EntitiesToBeChecked 
        {
            get => entities;
        }

        public BorderControl()
        {
            entities = new List<BaseEntity>();
        }

        public void AddEntity(BaseEntity entity)
        {
            entities.Add(entity);
        }
    }
}
