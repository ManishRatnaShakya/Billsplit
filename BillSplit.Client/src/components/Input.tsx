type InputProps = {
    type: string;
    placeholder?: string;
    value?: string;
    onChange?: (value: string) => void;
};

export function Input({ type, placeholder, value, onChange }: InputProps) {
    return (
        <input
            type={type}
            placeholder={placeholder}
            value={value}
            onChange={(e) => onChange?.(e.target.value)}
            className="border rounded px-3 py-2 w-full"
        />
    );
}
