using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Importa el namespace para usar TextMeshPro
using System.Globalization;

public class Calculadora : MonoBehaviour
{
    public TextMeshProUGUI resultadoTexto;
    private float numero1 = 0f;
    private float numero2 = 0f;
    private string operacion = "";

    void Start()
    {
        resultadoTexto.text = "0";
    }
    public void SetNumero(string num)
    {
        if (resultadoTexto.text == "0")
        {
            resultadoTexto.text = num;
        }
        else
        {
            resultadoTexto.text += num;
        }

    }


    public void SetOperacion(string op)
    {
        numero1 = float.Parse(resultadoTexto.text, CultureInfo.InvariantCulture.NumberFormat);
        Debug.Log("numero 1 " + numero1);
        operacion = op; // Guardamos la operación seleccionada
        resultadoTexto.text = "0"; // Limpia el texto para empezar con numero2
    }


    public void Calcular()
    {
        numero2 = float.Parse(resultadoTexto.text, CultureInfo.InvariantCulture.NumberFormat);
        Debug.Log("numero 2 " + numero2);
        float resultado = 0.0f;

        switch (operacion)
        {
            case "+":
                resultado = numero1 + numero2;
                break;
            case "-":
                resultado = numero1 - numero2;
                break;
            case "*":
                resultado = numero1 * numero2;
                break;
            case "/":
                if (numero2 != 0) resultado = numero1 / numero2;
                break;
        }

        resultadoTexto.text = resultado.ToString();
        numero1 = resultado;
        numero2 = 0.0f;
        operacion = "";

        /*
            Después de calcular, el resultado se guarda en numero1 para poder realizar cálculos encadenados.
            Y numero2 y operacion se reinician.
         */
    }
    public void Resetear()
    {
        numero1 = 0.0f;
        numero2 = 0.0f;
        operacion = "";
        resultadoTexto.text = "0"; // Restablece el texto inicial
    }

}
