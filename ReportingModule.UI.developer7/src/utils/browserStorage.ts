export class BrowserStorage {
    bucket: string;
    storage: Storage;
    set: (key: string, value: any) => void;
    get: (key: string) => any;
    remove: (key: string) => void;
    clear: () => void;

    constructor(bucketName, settings: any = null) {
        let bucket = bucketName,
            storage = settings ? settings.storage : window.localStorage;

        if (!this.canUseStorage(storage)) {
            console.log("Storage is full or not supported");
            this.set = (a, b) => { this.noop(); };
            this.get = (_) => { return this.noop(); };
            this.remove = (_) => { this.noop(); };
            this.clear = () => { this.noop(); };
            return;
        }

        this.set = (key, value) => { this.setInternal(storage, bucket, key, value); };
        this.get = (key) => { return this.getInternal(storage, bucket, key); };
        this.remove = (key) => { this.removeInternal(storage, bucket, key); };
        this.clear = () => { this.clearInternal(storage, bucket); };
    };

    private canUseStorage = (storage: Storage) => {
        if (!storage) {
            return false;
        }
        try {
            storage.setItem("rmtest", "abc");
            storage.removeItem("rmtest");
            return true;
        } catch (e) {
            console.log("Storage unavailable: " + e);
            return false;
        }
    };

    private noop = function () {
        console.log("Storage is full or not supported");
        return null;
    };

    private getBucketKey = (bucket: string, key: string) => {
        return bucket ? bucket + "|" + key : key;
    };

    private setInternal = (storage: Storage, bucket: string, key: string, value: any) => {
        storage[this.getBucketKey(bucket, key)] = JSON.stringify(value);
    };

    private getInternal = (storage: Storage, bucket: string, key: string) => {
        let value = storage[this.getBucketKey(bucket, key)];
        return value ? JSON.parse(value) : null;
    };

    private removeInternal = (storage: Storage, bucket: string, key: string) => {
        storage.removeItem(this.getBucketKey(bucket, key));
    };

    private clearInternal = (storage: Storage, bucket: string) => {
        let i = 0, l = storage.length, keys: string[] = [], key: string;
        for (i; i < l; i++) {
            key = storage.key(i);
            if (key && key.split("|")[0] === bucket) {
                keys.push(key);
            }
        }
        keys.forEach(function (k2) { storage.removeItem(k2); });
    };
}
