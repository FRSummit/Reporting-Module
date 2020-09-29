export class DecimalValueConverter {
    fromView(value) {
        if(isNaN(value)) return undefined;
        return Number(value);
    }
}