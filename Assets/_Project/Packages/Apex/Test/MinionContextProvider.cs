using System;
using Apex.AI;
using Apex.AI.Components;
using UnityEngine;

public class MinionContextProvider : MonoBehaviour, IContextProvider
{
    private MinionContext _context;

    public IAIContext GetContext(Guid aiId) => _context;

    public void OnEnable()
    {
        _context = new MinionContext();
    }
}

