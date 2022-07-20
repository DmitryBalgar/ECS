using UnityEngine;
using Unity.Entities;
public class DogMoveSystem : ComponentSystem
{
    private EntityQuery _query;
    protected override void OnCreate()
    {
        _query = GetEntityQuery(ComponentType.ReadOnly<DogMoveComponent>());
    }
    protected override void OnUpdate()
    {
        Entities.With(_query).ForEach((Entity entity, Transform transform, DogMoveComponent dogMove) => 
        {
            var pos = transform.position;
            pos.y += dogMove.MoveSpeed/1000;
            transform.position = pos;
        });
    }
}

