﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MkGame
{
    class Employes : IEnumerable
    {
        private readonly Employe[] _employes;
        public int Lenght {get{return _employes.Length;} }

        public Employes(Employe[] eArray) 
        {
            _employes = new Employe[eArray.Length];

            for (int i = 0; i < eArray.Length; i++)
            {
                _employes[i] = eArray[i];
            }
        }

        public Employe this[int i]
        {
            get
            {
                if (i >= 0 && i < _employes.Length)
                {
                    return _employes[i];
                }
                else
                {
                    throw new IndexOutOfRangeException(
                       "Попытка извлечь элемент с индексом " + i) ;
                }
            }
            set
            {
                if (i >= 0 && i < _employes.Length)
                {
                    _employes[i] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException(
                   "Попытка назначить элемент с индексом" + i);
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (Employe eml in _employes)
                yield return eml;
        }
    }
}