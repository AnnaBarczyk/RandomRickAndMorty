using RandomRickAndMorty.Entities;
using RandomRickAndMorty.Models;
using System.Collections.Generic;

namespace RandomRickAndMorty.Mapping
{
    public static class Mapper
    {
        public static Character ToEntity(CharacterModel model)
        {
            var entity = new Character
            {
                Id = model.Id,
                Name = model.Name,
                Species = model.Species,
                Image = model.Image
            };

            return entity;
        }

        public static List<Character> ToEntityList(List<CharacterModel> models)
        {
            List<Character> list = new List<Character>();
            foreach (var model in models)
            {
                list.Add(ToEntity(model));
            }
            return list;
        }

        public static CharacterModel ToModel(Character entity)
        {
            var model = new CharacterModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Species = entity.Species,
                Image = entity.Image
            };

            return model;
        }

        public static List<CharacterModel> ToModelList(List<Character> entities)
        {
            var list = new List<CharacterModel>();
            foreach (var entity in entities)
            {
                list.Add(ToModel(entity));
            }
            return list;
        }
    }
}
