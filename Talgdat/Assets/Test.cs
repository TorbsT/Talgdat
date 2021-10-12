using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test
{
    public static void Main()
    {
        List<Base> l = new List<Derived>();

        Invariant<Base> a = new InvariantClass<Derived>();
        Invariant<Derived> b = new InvariantClass<Derived>();
        Invariant<Derived> c = new InvariantClass<Base>();

        ICovariant<Base> d = new CovariantClass<Derived>();
        ICovariant<Derived> e = new CovariantClass<Derived>();
        ICovariant<Derived> f = new CovariantClass<Base>();

        CovariantClass<Base> x = new CovariantClass<Derived>();
        CovariantClass<Derived> y = new CovariantClass<Derived>();
        CovariantClass<Derived> z = new CovariantClass<Base>();

        IContravariant<Base> g = new ContravariantClass<Derived>();
        IContravariant<Derived> h = new ContravariantClass<Derived>();
        IContravariant<Derived> i = new ContravariantClass<Base>();

    }
}
public class Base { }
public class Derived : Base { }
public interface Invariant<T> { }
public class InvariantClass<T> : Invariant<T> { }
public interface ICovariant<out T> { }
public class CovariantClass<T> : ICovariant<T> { }
public interface IContravariant<in T> { }
public class ContravariantClass<T> : IContravariant<T> { }