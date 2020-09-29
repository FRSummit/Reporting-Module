
export function getMockLocalStorage() {
  let storage: Storage = {} as any as Storage;
  storage.removeItem = (key: any) => {
    delete storage[key];
  };
  storage.setItem = (key: any, value: any) => {
    storage[key] = value;
  };
  storage.key = (index: number) => {
    let keys = Object.keys(storage);
    keys.shift();
    keys.shift();
    keys.shift();
    return keys[index];
  }
  Object.defineProperty(storage, "length", {
    get: () => {
      return Object.keys(storage).length - 3;
    }
  });
  return storage;
}

