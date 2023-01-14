import { useState, useEffect } from "react";
//https://www.youtube.com/watch?v=eQrbjvn_fSc&list=PL0Zuz27SZ-6PRCpm9clX0WiBEMB70FWwd&index=6

const getLocalValue = (key, initValue) => {
  if (typeof window === "undefined") return initValue;

  const localValue = JSON.parse(localStorage.getItem(key));
  if (localValue) return localValue;

  if (initValue instanceof Function) return initValue();
};

const useLocalStorage = (key, initValue) => {
  const [value, setValue] = useState(() => {
    return getLocalValue(key, initValue);
  });

  useEffect(() => {
    localStorage.setItem(key, JSON.stringify(value));
  }, [key, value]);

  return [value, setValue];
};

export default useLocalStorage;
