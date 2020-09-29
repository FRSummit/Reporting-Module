export class NumberValueConverter {
    fromView(value) {
        if(isNaN(value)) return undefined;
        return Number(value);
    }
}