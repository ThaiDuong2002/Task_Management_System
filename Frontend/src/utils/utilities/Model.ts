export class Model {
  public readonly id!: string;

  public readonly createdAt!: Date | string | number;
  public readonly updatedAt!: Date | string | number;
}

export const dataInjection = <T extends Model>(
  constructor: new () => T,
  data: any
) => {
  if (data instanceof constructor) {
    return data;
  }

  const instance = new constructor();

  Object.assign(instance, data);

  return instance;
};
