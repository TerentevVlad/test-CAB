using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace DI
{
    public class DIContainer : IDisposable
    {
        private Dictionary<Type, BindProvider> _providers;

        private HashSet<Type> _contractTypes;

        private DIContainer ParentDiContainer { get; set; }
        


        public DIContainer()
        {
            ParentDiContainer = null;
            _providers = new Dictionary<Type, BindProvider>();
            _contractTypes = new HashSet<Type>();
        }

        public DIContainer(DIContainer parentDiContainer)
        {
            ParentDiContainer = parentDiContainer;
            _providers = new Dictionary<Type, BindProvider>();
            _contractTypes = new HashSet<Type>();
        }

        public Binder<T> Bind<T>()
        {
            var type = typeof(T);
            if (_contractTypes.Contains(type))
                throw new Exception(type + " already bind");

            return new Binder<T>(this);
        }


        public class Binder<T>
        {
            private readonly DIContainer _diContainer;

            public Binder(DIContainer diContainer)
            {
                _diContainer = diContainer;
                _diContainer._contractTypes.Add(typeof(T));
                _diContainer._providers.Add(typeof(T), new BindProvider());
            }

            public void FromInstance(T instance)
            {
                _diContainer._providers[typeof(T)].Instance = instance;
            }
        }


        private List<Type> _notBindedHashSet = new List<Type>();

        public void RunInstall()
        {
            _notBindedHashSet = new List<Type>(_contractTypes);

            while (_notBindedHashSet.Count > 0)
            {
                var currentContract = _notBindedHashSet.First();
                if (_providers[currentContract].HasInstance)
                {
                    _notBindedHashSet.Remove(currentContract);
                }
                else
                {
                    Install(currentContract);
                }
            }
        }

        private void Install(Type type)
        {
            var currentContract = type;
            var constructorParams = GetConstructorParams(currentContract);
            _providers[type].InInstallProcess = true;
            ValidateTypesForConstruct(currentContract, constructorParams);
            ValidateCycleDependencies(currentContract, constructorParams);

            foreach (var parameterInfo in constructorParams)
            {
                var parameterType = parameterInfo.ParameterType;
                var bindProvider = GetBindProvider(parameterType);
                if (bindProvider.HasInstance == false)
                {
                    Install(parameterInfo.ParameterType);
                    return;
                }
            }

            var types = constructorParams.Select(v => v.ParameterType).ToArray();
            ConstructorInfo ctor = type.GetConstructor(types);

            List<object> objects = new List<object>();
            foreach (var parameterType in types)
            {
                objects.Add(GetBindProvider(parameterType).Instance);
            }

            object instance = ctor.Invoke(objects.ToArray());
            _providers[type].InInstallProcess = false;
            _providers[type].Instance = instance;
            _notBindedHashSet.Remove(type);
        }


        private List<ParameterInfo> GetConstructorParams(Type type)
        {
            var ctors = type.GetConstructors();
            var ctor = ctors[0];
            return ctor.GetParameters().ToList();
        }

        private void ValidateTypesForConstruct(Type contract, List<ParameterInfo> paramsInfo)
        {
            foreach (var parameter in paramsInfo)
            {
                if (HasContract(parameter.ParameterType) == false)
                {
                    throw new Exception("Could not be found " + parameter.ParameterType + " when creating " + contract);
                }
            }
        }

        public BindProvider GetBindProvider(Type contract)
        {
            if (HasContract(contract))
            {
                if (_providers.ContainsKey(contract) == false)
                {
                    if (ParentDiContainer == null)
                    {
                        throw new Exception(contract + " could not found");
                    }
                    else
                        return ParentDiContainer.GetBindProvider(contract);
                }
                else
                    return _providers[contract];
            }

            throw new Exception(contract + " could not found");
        }

        public bool HasContract(Type contract)
        {
            var hasContract = _contractTypes.Contains(contract);

            if (hasContract) return true;
            else
            {
                if (ParentDiContainer == null)
                    return false;
                return ParentDiContainer.HasContract(contract);
            }
        }


        private object Resolve(Type contract)
        {
            if (HasContract(contract))
            {
                if (_providers.ContainsKey(contract) == false)
                {
                    if (ParentDiContainer == null)
                    {
                        throw new Exception(contract + " could not found");
                    }
                    else
                        return ParentDiContainer.Resolve(contract);
                }
                else
                    return _providers[contract].Instance;
            }

            throw new Exception(contract + " could not found");
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        private void ValidateCycleDependencies(Type contract, List<ParameterInfo> parametersInfo)
        {
            foreach (var parameterInfo in parametersInfo)
            {
                var provider = GetBindProvider(parameterInfo.ParameterType);
                if (provider.InInstallProcess)
                {
                    throw new Exception("Cycle Dependencies: " + contract + " and " + parameterInfo.ParameterType);
                }
            }
        }

        public void Dispose()
        {
            _providers.Clear();
            _contractTypes.Clear();
        }
    }

    public class BindProvider
    {
        public object Instance { get; set; }
        public bool InInstallProcess { get; set; }

        public BindProvider()
        {
            Instance = null;
        }

        public bool HasInstance => Instance != null;

        public BindProvider(object instance)
        {
            Instance = instance;
        }
    }
}