type User =
  | {
      idPerson: string;
      name: string;
      surname: string;
      email: string;
      password: string;
    }
  | undefined;

export default User;
