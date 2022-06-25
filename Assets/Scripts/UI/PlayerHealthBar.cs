using System.Globalization;
using UnityEngine;
using UnityEngine.UI;


	public class PlayerHealthBar : MonoBehaviour
	{
		/// <summary>
		/// The text element to display information on
		/// </summary>
		public GameObject displayBar;
		public GameObject player;

		/// <summary>
		/// The highest health that the base can go to
		/// </summary>
		protected float m_MaxHealth = 100f;

		/// <summary>
		/// Get the max health of the player base
		/// </summary>
		protected virtual void Start()
		{
		
		}

		

		/// <summary>
		/// Get the current health of the home base and display it on m_Display
		/// </summary>
		void Update()
		{
		displayBar.GetComponent<Slider>().value = player.GetComponent<Character>().Health / m_MaxHealth;

	}
}

