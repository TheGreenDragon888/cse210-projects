using System;

/*
My final project is a economy simulator.
It currently has all the classes and most of the methods.
The base class structure is all here, but the more
nuance of calculating prices for trade among large quantities
of agents is still to be decided.

There will be two market types analyzed: Free and Regulated
The simulation will display a summary of the difference between
the two upon completion. I'm still figuring out exactly how I
want to display that.
*/

class Program
{
    static void Main(string[] args)
    {
        // Demo for final projecyS
        var simulator = new Simulator();
        simulator.RunSimulation();
    }
}