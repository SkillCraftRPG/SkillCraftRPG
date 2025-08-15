export default defineI18nConfig(() => ({
  numberFormats: {
    fr: {
      attack: {
        style: "decimal",
        minimumFractionDigits: 0,
        maximumFractionDigits: 0,
      },
      capacity: {
        style: "decimal",
        minimumFractionDigits: 0,
        maximumFractionDigits: 1,
      },
      defense: {
        style: "decimal",
        minimumFractionDigits: 0,
        maximumFractionDigits: 0,
      },
      integer: {
        style: "decimal",
        minimumFractionDigits: 0,
        maximumFractionDigits: 0,
      },
      price: {
        style: "decimal",
        minimumFractionDigits: 0,
        maximumFractionDigits: 2,
      },
      resistance: {
        style: "decimal",
        minimumFractionDigits: 0,
        maximumFractionDigits: 0,
      },
      volume: {
        style: "decimal",
        minimumFractionDigits: 0,
        maximumFractionDigits: 2,
      },
      weight: {
        style: "decimal",
        minimumFractionDigits: 0,
        maximumFractionDigits: 2,
      },
    },
  },
}));
